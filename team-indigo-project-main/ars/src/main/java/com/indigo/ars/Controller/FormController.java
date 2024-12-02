package com.indigo.ars.Controller;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.indigo.ars.DTO.FormDTO;
import com.indigo.ars.DTO.request.EditFormRequest;
import com.indigo.ars.DTO.response.PageReportsResponse;
import com.indigo.ars.Services.FormService;
import lombok.AllArgsConstructor;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.messaging.simp.SimpMessagingTemplate;
import org.springframework.web.bind.annotation.*;
import com.indigo.ars.DTO.request.EditFormRequest;

import java.time.LocalDateTime;
import java.util.Date;

@RestController
@RequestMapping("/form")
@AllArgsConstructor
public class FormController {

    private final FormService formService;
    private final SimpMessagingTemplate simpMessagingTemplate;

    @GetMapping
    public ResponseEntity<PageReportsResponse> getAllForms(
            @RequestParam(value = "currentPage", defaultValue = "0") Integer page,
            @RequestParam(value = "pageSize", defaultValue = "10") Integer size,
            @RequestParam(value = "id", required = false) Integer id,
            @RequestParam(value = "reporter", required = false) String reporterName,
            @RequestParam(value = "type", required = false) String incidentType,
            @RequestParam(value = "severity", required = false) String severityLevel,
            @RequestParam(value = "date", required = false) String date,
            @RequestParam(value = "status", required = false) String status,
            @RequestParam(value = "building", required = false) String buildingName) throws Exception {

        Pageable pageable = PageRequest.of(page, size);
        PageReportsResponse response = formService.getAllForms(pageable, reporterName, id, incidentType, severityLevel, date, status, buildingName);
        return ResponseEntity.ok(response);
    }

    @GetMapping("/{id}")
    public ResponseEntity<?> getFormById(@PathVariable int id) throws JsonProcessingException {
        return ResponseEntity.ok(formService.getFormById(id));
    }

    @PutMapping("/{id}/complete")
    public ResponseEntity<?> completeForm(@PathVariable int id){
        try{
            formService.completeForm(id);
            return new ResponseEntity<>("Status Changed", HttpStatus.OK);
        }
        catch (Exception e){
            return new ResponseEntity<>("Error", HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }

    @PostMapping("/{id}/edit")
    public ResponseEntity<?> editForm(@PathVariable int id, @RequestBody EditFormRequest form) {
        try{
            return new ResponseEntity<>(formService.editForm(id, form), HttpStatus.CREATED);
        }
        catch (Exception e){
            return new ResponseEntity<>("Error", HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }

    @PutMapping("/{id}/delete")
    public ResponseEntity<?> deleteForm(@PathVariable int id){
        try{
            formService.deleteForm(id);
            return new ResponseEntity<>("Form Deleted", HttpStatus.OK);
        }
        catch (Exception e){
            return new ResponseEntity<>("Error", HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }


    @GetMapping("/reporter/{reporter}")
    public ResponseEntity<?> getFormsByReporter(
            @PathVariable("reporter") String reporter,
            @RequestParam(value = "currentPage", defaultValue = "0") Integer page,
            @RequestParam(value = "pageSize", defaultValue = "10") Integer size,
            @RequestParam(value = "id", required = false) Integer id,
            @RequestParam(value = "reporter", required = false) String reporterName,
            @RequestParam(value = "type", required = false) String incidentType,
            @RequestParam(value = "severity", required = false) String severityLevel,
            @RequestParam(value = "date", required = false) String date,
            @RequestParam(value = "status", required = false) String status,
            @RequestParam(value = "building", required = false) String buildingName) {
        Pageable pageable = PageRequest.of(page, size);
        PageReportsResponse response = formService.getFormsByReporter(pageable, reporter, reporterName, id, incidentType, severityLevel, date, status, buildingName);
        return ResponseEntity.ok(response);
    }

//    @GetMapping("/{incidentLocation}")
//    public ResponseEntity<?> getFormByIncidentLocation(@RequestBody BuildingDTO incidentLocation) {
//        return ResponseEntity.ok(formService.getFormByIncidentLocation(incidentLocation));
//    }

    @PostMapping
    public ResponseEntity<?> addForm(@RequestBody FormDTO form) throws JsonProcessingException {
        try{
            formService.save(form);
            simpMessagingTemplate.convertAndSend("/form", form);
            return new ResponseEntity<>("Report Created", HttpStatus.OK);
        }
        catch (Exception e){
            return new ResponseEntity<>("Error", HttpStatus.INTERNAL_SERVER_ERROR);
        }

    }
}
