package com.indigo.ars.Controller;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.indigo.ars.DTO.response.FormFullResponseDTO;
import com.indigo.ars.DTO.response.FormVersionResponseDTO;
import com.indigo.ars.DTO.response.PageReportsResponse;
import com.indigo.ars.Services.VersionService;
import com.indigo.ars.exceptions.ResourceNotFound;
import lombok.AllArgsConstructor;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/version")
@AllArgsConstructor
public class VersionController {

    private final VersionService versionService;

    @GetMapping("/{id}/version/{version}")
    public ResponseEntity<?> getSpecificFormVersion(@PathVariable int id, @PathVariable int version) {
        try {
            FormVersionResponseDTO response = versionService.getFormVersion(id, version);
            return ResponseEntity.ok(response);
        } catch (ResourceNotFound ex) {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body(ex.getMessage());
        } catch (Exception ex) {
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body("An error occurred");
        }
    }


    @GetMapping("/{id}/versions")
    public ResponseEntity<?> getVersionNumbersOfForm(@PathVariable int id){
        try {
            int versions = versionService.getVersions(id);
            return ResponseEntity.ok(versions);
        } catch (Exception ex) {
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body("An error occurred");
        }
    }

}
