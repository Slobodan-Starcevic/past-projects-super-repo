package com.indigo.ars.Services;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.indigo.ars.Converters.BuildingConverter;
import com.indigo.ars.Converters.FormConverter;
import com.indigo.ars.DTO.BuildingDTO;
import com.indigo.ars.DTO.FormDTO;
import com.indigo.ars.DTO.FormListDTO;
import com.indigo.ars.DTO.request.EditFormRequest;
import com.indigo.ars.DTO.response.FilterCountsResponse;
import com.indigo.ars.DTO.response.FormFullResponseDTO;
import com.indigo.ars.DTO.response.PageReportsResponse;
import com.indigo.ars.Entity.Building;
import com.indigo.ars.Entity.Employee;
import com.indigo.ars.Entity.Form;
import com.indigo.ars.Entity.FormVersion;
import com.indigo.ars.Repository.BuildingRepository;
import com.indigo.ars.Repository.EmployeeRepository;
import com.indigo.ars.Repository.FormRepository;
import com.indigo.ars.Repository.FormVersionRepository;
import com.indigo.ars.exceptions.ResourceNotFound;
import jakarta.persistence.criteria.Expression;
import lombok.AllArgsConstructor;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.domain.Specification;
import org.springframework.format.annotation.DateTimeFormat;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.RequestParam;


import java.lang.reflect.Array;
import java.net.URISyntaxException;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.*;
import java.util.stream.Collectors;


@Service
@AllArgsConstructor
public class FormService {

    private final FormRepository formRepository;

    private final FormVersionRepository formVersionRepository;

    private final  BuildingRepository buildingRepository;

    private final EmployeeRepository employeeRepository;

    private final MailgunEmailService mailgunEmailService;

    public PageReportsResponse getAllForms(Pageable pageable, String reporterName, Integer id, String incidentType, String severityLevel, String date, String status, String buildingName) throws Exception {

        Specification<Form> spec = CreateSpec(id, reporterName, incidentType, severityLevel, date, status, buildingName);

        List<Form> allForms = formRepository.findAll(spec);


        Page<Form> page = formRepository.findAll(spec, pageable);

        PageReportsResponse response = new PageReportsResponse();

        response.setReports(page.stream()
                .map(form -> FormListDTO.builder()
                        .id(form.getId())
                        .status(form.getStatus())
                        .employeeName(form.getReporter().getFirstName() + " " + form.getReporter().getLastName())
                        .date(form.getDatetime().format(DateTimeFormatter.ofPattern("dd.MM.yyyy")))
                        .building(form.getIncidentLocation().getAddress())
                        .type(form.getType())
                        .severity(form.getSeverity())
                        .build())
                .collect(Collectors.toList()));

        response.setFilterCounts(createFilterHashMaps(allForms));

        response.setCurrentPage(pageable.getPageNumber());
        response.setTotalElements(allForms.size());
        response.setTotalPage((int)Math.ceil((double)allForms.size() / pageable.getPageSize()));

        return response;
    }

    public PageReportsResponse getFormsByReporter(Pageable pageable, String email, String reporterName, Integer id, String incidentType, String severityLevel, String date, String status, String buildingName) {

        Specification<Form> spec = CreateSpec(id, email, incidentType, severityLevel, date, status, buildingName);

        List<Form> allForms = formRepository.findAll(spec);


        Page<Form> page = formRepository.findAll(spec, pageable);


        PageReportsResponse response = new PageReportsResponse();

        response.setReports(page.getContent().stream()
                .map(form -> FormListDTO.builder()
                        .id(form.getId())
                        .status(form.getStatus())
                        .employeeName(form.getReporter().getFirstName() + " " + form.getReporter().getLastName())
                        .date(form.getDatetime().format(DateTimeFormatter.ofPattern("dd.MM.yyyy")))
                        .type(form.getType())
                        .building(form.getIncidentLocation().getAddress())
                        .severity(form.getSeverity())
                        .build())
                .collect(Collectors.toList()));

        response.setFilterCounts(createFilterHashMaps(allForms));

        response.setCurrentPage(pageable.getPageNumber());
        response.setTotalElements(allForms.size());
        response.setTotalPage((int)Math.ceil((double)allForms.size() / pageable.getPageSize()));

        return response;
    }

    public FormFullResponseDTO getFormById(int id) throws JsonProcessingException {

        Form form = formRepository.findById(id).get();

        return FormFullResponseDTO.builder()
                .data(FormConverter.FormConverterEntityToDTO(form))
                .date(form.getDatetime().format(DateTimeFormatter.ofPattern("dd/MM/yyyy")))
                .employeeName(form.getReporter().getFirstName() + " " + form.getReporter().getLastName())
                .id(form.getId())
                .severity(form.getSeverity())
                .type(form.getType())
                .status(form.getStatus())
                .build();
    }

    public void save(FormDTO form) throws JsonProcessingException {
        Form formEntity = FormConverter.FormConverterDTOtoEntity(form);

        Building building = buildingRepository.getBuildingByAddress(form.getIncident().getLocation());

        if (building == null) {
            throw new ResourceNotFound("Building not found");
        }
        else {
            formEntity.setIncidentLocation(building);
        }

        Employee employee = employeeRepository.getEmployeeByEmail(form.getReporter().getEmail());

        String fullName = form.getReporter().getName();
        String[] nameParts = fullName.split(" ");

        if (employee == null) {
            Employee employeeNew = Employee.builder()
                    .email(form.getReporter().getEmail())
                    .firstName(nameParts[0])
                    .lastName(nameParts.length > 1 ? nameParts[1] : "")
                    .phoneNumber(form.getReporter().getPhone())
                    .role("user")
                    .build();

            employeeRepository.save(employeeNew);

            formEntity.setReporter(employeeNew);
        }
        else {
            formEntity.setReporter(employee);
        }
        formEntity.setStatus("waiting");

        formRepository.save(formEntity);

        sendFormCreatedNotification(formEntity); //sends email for every new form
    }

    public void completeForm(int id){
        Form form = formRepository.findById(id).get();
        form.setStatus("complete");
        formRepository.save(form);
    }

    private Specification<Form> CreateSpec(Integer id, String reporterName, String incidentType, String severityLevel, @RequestParam @DateTimeFormat(pattern = "yyyy-MM-dd") String date, String status, String buildingName) {
        Specification<Form> spec = Specification.where(null);


        if (incidentType != null && !incidentType.isEmpty()) {
            spec = spec.and((root, query, criteriaBuilder) -> {
                // PostgreSQL specific function for array comparison
                Expression<String[]> typePath = root.get("type"); // Ensure that "type" is the correct field name in your entity.
                Expression<String[]> incidentTypeArray = criteriaBuilder.literal(new String[]{incidentType}); // Creates a literal array to compare with the entity field.

                // The "array_overlap" function should return a boolean value indicating if there's an overlap between the two arrays.
                Expression<Boolean> typePredicate = criteriaBuilder.function("array_overlap_custom", Boolean.class, typePath, incidentTypeArray);

                // The predicate is true if there's an overlap (array_overlap function returns true).
                return criteriaBuilder.isTrue(typePredicate);
            });
        }


        if(id != null && id > 0){
            spec = spec.and((root, query, cb) ->
                    cb.equal(
                            root.get("id"),
                            id
                    )
            );
        }


        if(severityLevel != null){
            spec = spec.and((root, query, cb) ->
                    cb.equal(
                            root.get("severity"),
                            severityLevel
                    )
            );
        }

        if (date != null) {
            LocalDate parsedDate = LocalDate.parse(date, DateTimeFormatter.ofPattern("yyyy-MM-dd"));
            spec = spec.and((root, query, cb) -> {
                // Compare the date part of the LocalDateTime with the parsed date
                return cb.equal(cb.function("DATE", LocalDate.class, root.get("datetime")), parsedDate);
            });
        }

        if(status != null){
            spec = spec.and((root, query, cb) ->
                    cb.equal(
                            root.get("status"),
                            status
                    )
            );
        }

        if (buildingName != null) {
            spec = spec.and((root, query, cb) ->
                    cb.equal(
                            root.get("incidentLocation").get("address"),
                            buildingName
                    )
            );
        }

        if (reporterName != null) {
            spec = spec.and((root, query, cb) -> {
                // Concatenate the firstName and lastName of the reporter
                Expression<String> fullName = cb.concat(
                        root.get("reporter").get("firstName"),
                        root.get("reporter").get("lastName")
                );

                // Compare the concatenated name with the reporterName
                return cb.equal(fullName, reporterName);
            });
        }

        return spec;
    }

    private FilterCountsResponse createFilterHashMaps(List<Form> forms){
        FilterCountsResponse filterCountsResponse = new FilterCountsResponse();
        filterCountsResponse.setReporterCounts(new HashMap<>());
        filterCountsResponse.setIncidentTypeCounts(new HashMap<>());
        filterCountsResponse.setSeverityCounts(new HashMap<>());
        filterCountsResponse.setDateCounts(new HashMap<>());
        filterCountsResponse.setStatusCounts(new HashMap<>());
        filterCountsResponse.setBuildingCounts(new HashMap<>());

        for (Form form : forms) {
            String reporterName = form.getReporter().getFirstName() + form.getReporter().getLastName();
            filterCountsResponse.getReporterCounts().merge(reporterName, 1, Integer::sum);

            for (String type : form.getType()) {
                filterCountsResponse.getIncidentTypeCounts().merge(type, 1, Integer::sum);
            }

            filterCountsResponse.getSeverityCounts().merge(form.getSeverity(), 1, Integer::sum);

            String dateKey = form.getDatetime().toLocalDate().toString();
            filterCountsResponse.getDateCounts().merge(dateKey, 1, Integer::sum);

            filterCountsResponse.getStatusCounts().merge(form.getStatus(), 1, Integer::sum);

            String buildingName = form.getIncidentLocation().getAddress();
            filterCountsResponse.getBuildingCounts().merge(buildingName, 1, Integer::sum);
        }

        return filterCountsResponse;
    }

    public void deleteForm(int id){
        formVersionRepository.deleteFormsById(id);
        formRepository.deleteById(id);
    }

    public FormFullResponseDTO editForm(int id, EditFormRequest formRequest) throws JsonProcessingException {
        Form oldForm = formRepository.findById(id).get();

        Employee reporter = employeeRepository.getEmployeeByEmail(formRequest.getEmail());

        Integer lastVersionNumber = formVersionRepository.getLastVersionNumber(id);
        int nextVersionNumber;
        if (lastVersionNumber == null) {
            nextVersionNumber = 1;
        } else {
            nextVersionNumber = lastVersionNumber + 1;
        }

        FormVersion version = FormVersion.builder()
                .version(nextVersionNumber)
                .message(formRequest.getMessage())
                .reporter(reporter)
                .data(oldForm.getData())
                .datetime(LocalDateTime.now())
                .form(oldForm)
                .build();

        formVersionRepository.save(version);

        Building building = buildingRepository.getBuildingByAddress(formRequest.getNewForm().getIncident().getLocation());

        if (building == null) {
            Building buildingNew = buildingRepository.getBuildingByAddress("Main office");
            oldForm.setIncidentLocation(buildingNew);
        }
        else {
            oldForm.setIncidentLocation(building);
        }

        Employee employee = employeeRepository.getEmployeeByEmail(formRequest.getNewForm().getReporter().getEmail());

        if (employee == null) {
            Employee employeeNew = employeeRepository.getEmployeeByEmail("john.doe@example.com");
            oldForm.setReporter(employeeNew);
        }
        else {
            oldForm.setReporter(employee);
        }

        oldForm.setStatus("edited");

        oldForm.setData(FormConverter.ConvertFormDTOToJson(formRequest.getNewForm()));
        oldForm.setType(formRequest.getNewForm().getIncident().getTypeOfIncident());
        oldForm.setSeverity(formRequest.getNewForm().getProcedure().getHowLikely());

        formRepository.save(oldForm);


        return FormFullResponseDTO.builder()
                .data(FormConverter.FormConverterEntityToDTO(oldForm))
                .id(oldForm.getId())
                .date(oldForm.getDatetime().format(DateTimeFormatter.ofPattern("dd/MM/yyyy")))
                .employeeName(oldForm.getReporter().getFirstName() + " " + oldForm.getReporter().getLastName())
                .id(oldForm.getId())
                .severity(oldForm.getSeverity())
                .type(oldForm.getType())
                .status(oldForm.getStatus())
                .build();
    }



    private void sendFormCreatedNotification(Form form) {
        String to = "copaco608@gmail.com"; // Replace with the actual recipient email address
        String subject = "Copaco: New Incident Form Submitted";
        String text = "A new form has been submitted. \n" +
                "Form ID: " + form.getId() + "\n" +
                "Go to the Accident Reporting System to access more details.";

        try {
            mailgunEmailService.sendSimpleMessage(to, subject, text);
        } catch (URISyntaxException e) {
            // Handle the exception appropriately (log or throw a custom exception)
            e.printStackTrace();
        }
    }
}
