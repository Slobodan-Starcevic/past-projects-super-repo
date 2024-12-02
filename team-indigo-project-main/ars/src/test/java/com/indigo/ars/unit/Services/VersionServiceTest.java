package com.indigo.ars.unit.Services;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.indigo.ars.DTO.response.FormVersionResponseDTO;
import com.indigo.ars.Entity.Employee;
import com.indigo.ars.Entity.Form;
import com.indigo.ars.Entity.FormVersion;
import com.indigo.ars.Repository.FormVersionRepository;
import com.indigo.ars.Services.VersionService;
import com.indigo.ars.exceptions.ResourceNotFound;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.*;
import org.mockito.junit.jupiter.MockitoExtension;

import java.time.LocalDateTime;
@ExtendWith(MockitoExtension.class)
public class VersionServiceTest {

    @Mock
    private FormVersionRepository formVersionRepository;

    @InjectMocks
    private VersionService versionService;



    @Test
    void getFormVersion_Found() throws JsonProcessingException {
        int id = 1;
        int version = 1;

        Employee employeeEntity = Employee.builder()
                .firstName("John")
                .lastName("Doe")
                .email("john.doe@example.com")
                .phoneNumber("1234567890")
                .role("Developer")
                .build();

        Form formEntity = Form.builder()
                .id(1)
                .build();

        FormVersion mockFormVersion = FormVersion.builder()
                .id(1)
                .version(1)
                .reporter(employeeEntity)
                .form(formEntity)
                .datetime(LocalDateTime.now())
                .data("Sample data")
                .message("Sample message")
                .build();

        when(formVersionRepository.getFormVersion(id, version)).thenReturn(mockFormVersion);

        FormVersionResponseDTO result = versionService.getFormVersion(id, version);

        verify(formVersionRepository, times(1)).getFormVersion(any(Integer.class), any(Integer.class));

        assertEquals(1, result.getVersion());
        assertEquals(result.getEmployeeName(), "John Doe");
        assertEquals(result.getMessage(), "Sample message");
    }

    @Test
    void getFormVersion_NotFound() {
        int id = 1;
        int version = 1;

        when(formVersionRepository.getFormVersion(id, version)).thenReturn(null);

        assertThrows(ResourceNotFound.class, () -> versionService.getFormVersion(id, version));
    }

    @Test
    void getVersions() {
        int id = 1;
        Integer lastVersionNumber = 5;

        when(formVersionRepository.getLastVersionNumber(id)).thenReturn(lastVersionNumber);

        int result = versionService.getVersions(id);

        assertEquals(lastVersionNumber, result);
    }
}


