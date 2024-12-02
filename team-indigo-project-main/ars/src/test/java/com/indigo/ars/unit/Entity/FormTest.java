package com.indigo.ars.unit.Entity;

import com.indigo.ars.Entity.Building;
import com.indigo.ars.Entity.Employee;
import com.indigo.ars.Entity.Form;
import org.junit.jupiter.api.Test;

import java.time.LocalDateTime;
import java.util.Arrays;
import java.util.List;

import static org.assertj.core.api.Assertions.assertThat;

public class FormTest {

    @Test
    public void testNoArgsConstructor() {
        Form form = new Form();
        assertThat(form).isNotNull();
    }

    @Test
    public void testAllArgsConstructor() {
        Employee reporter = new Employee();
        Building incidentLocation = new Building();
        List<String> type = Arrays.asList("Type1", "Type2");
        LocalDateTime datetime = LocalDateTime.now();

        Form form = new Form(1, reporter, incidentLocation, type, datetime, "data", "status", "severity");

        assertThat(form.getId()).isEqualTo(1);
        assertThat(form.getReporter()).isEqualTo(reporter);
        assertThat(form.getIncidentLocation()).isEqualTo(incidentLocation);
        assertThat(form.getType()).isEqualTo(type);
        assertThat(form.getDatetime()).isEqualTo(datetime);
        assertThat(form.getData()).isEqualTo("data");
        assertThat(form.getStatus()).isEqualTo("status");
        assertThat(form.getSeverity()).isEqualTo("severity");
    }

    @Test
    public void testBuilder() {
        Employee reporter = new Employee();
        Building incidentLocation = new Building();
        List<String> type = Arrays.asList("Type1", "Type2");
        LocalDateTime datetime = LocalDateTime.now();

        Form form = Form.builder()
                .id(1)
                .reporter(reporter)
                .incidentLocation(incidentLocation)
                .type(type)
                .datetime(datetime)
                .data("data")
                .status("status")
                .severity("severity")
                .build();

        assertThat(form.getId()).isEqualTo(1);
        assertThat(form.getReporter()).isEqualTo(reporter);
        assertThat(form.getIncidentLocation()).isEqualTo(incidentLocation);
        assertThat(form.getType()).isEqualTo(type);
        assertThat(form.getDatetime()).isEqualTo(datetime);
        assertThat(form.getData()).isEqualTo("data");
        assertThat(form.getStatus()).isEqualTo("status");
        assertThat(form.getSeverity()).isEqualTo("severity");
    }

    @Test
    public void testLombokAnnotations() {
        Employee reporter = new Employee();
        Building incidentLocation = new Building();
        List<String> type = Arrays.asList("Type1", "Type2");
        LocalDateTime datetime = LocalDateTime.now();

        Form form1 = Form.builder()
                .id(1)
                .reporter(reporter)
                .incidentLocation(incidentLocation)
                .type(type)
                .datetime(datetime)
                .data("data")
                .status("status")
                .severity("severity")
                .build();

        Form form2 = Form.builder()
                .id(1)
                .reporter(reporter)
                .incidentLocation(incidentLocation)
                .type(type)
                .datetime(datetime)
                .data("data")
                .status("status")
                .severity("severity")
                .build();

        assertThat(form1).isEqualTo(form2);
        assertThat(form1.hashCode()).isEqualTo(form2.hashCode());
        assertThat(form1.toString()).isNotBlank();
    }
    @Test
    public void testDataAnnotation() {
        Employee reporter = new Employee();
        Building incidentLocation = new Building();
        List<String> type = Arrays.asList("Type1", "Type2");
        LocalDateTime datetime = LocalDateTime.now();

        Form form1 = Form.builder()
                .id(1)
                .reporter(reporter)
                .incidentLocation(incidentLocation)
                .type(type)
                .datetime(datetime)
                .data("data")
                .status("status")
                .severity("severity")
                .build();

        Form form2 = Form.builder()
                .id(1)
                .reporter(reporter)
                .incidentLocation(incidentLocation)
                .type(type)
                .datetime(datetime)
                .data("data")
                .status("status")
                .severity("severity")
                .build();

        //Tests for the built-in methods of the @Data annotation

        // isEqual
        assertThat(form1).isEqualTo(form2);

        // hashCode
        assertThat(form1.hashCode()).isEqualTo(form2.hashCode());

        assertThat(form1.toString()).isEqualTo(form2.toString());

        // Getters
        assertThat(form1.getId()).isEqualTo(1);
        assertThat(form1.getReporter()).isEqualTo(reporter);
        assertThat(form1.getIncidentLocation()).isEqualTo(incidentLocation);
        assertThat(form1.getType()).isEqualTo(type);
        assertThat(form1.getDatetime()).isEqualTo(datetime);
        assertThat(form1.getData()).isEqualTo("data");
        assertThat(form1.getStatus()).isEqualTo("status");
        assertThat(form1.getSeverity()).isEqualTo("severity");

        // setters
        form1.setId(2);
        assertThat(form1.getId()).isEqualTo(2);
    }
}

