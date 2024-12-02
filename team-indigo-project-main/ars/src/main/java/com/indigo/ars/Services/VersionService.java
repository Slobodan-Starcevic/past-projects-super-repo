package com.indigo.ars.Services;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.indigo.ars.Converters.EmployeeConverter;
import com.indigo.ars.Converters.FormConverter;
import com.indigo.ars.DTO.response.FormFullResponseDTO;
import com.indigo.ars.DTO.response.FormVersionResponseDTO;
import com.indigo.ars.Entity.FormVersion;
import com.indigo.ars.Repository.FormVersionRepository;
import com.indigo.ars.exceptions.ResourceNotFound;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

import java.time.format.DateTimeFormatter;
import java.util.Objects;

@Service
@AllArgsConstructor
public class VersionService {

    private final FormVersionRepository formVersionRepository;

    public FormVersionResponseDTO getFormVersion(int id, int version) throws JsonProcessingException {

        FormVersion form = formVersionRepository.getFormVersion(id, version);

        if (form == null) {
            throw new ResourceNotFound("Form version not found");
        }

        return FormVersionResponseDTO.builder()
                .employeeName(EmployeeConverter.EmployeeConverterToName(form.getReporter()))
                .dateTime(form.getDatetime().format(DateTimeFormatter.ofPattern("dd/MM/yyyy")))
                .message(form.getMessage())
                .data(FormConverter.FormConverterVersionEntityToDTO(form))
                .version(form.getVersion())
                .build();
    }

    public int getVersions(int id) {
        Integer lastVersionNumber = formVersionRepository.getLastVersionNumber(id);
        return Objects.requireNonNullElse(lastVersionNumber, 0);
    }
}
