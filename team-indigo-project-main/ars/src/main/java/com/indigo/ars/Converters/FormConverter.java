package com.indigo.ars.Converters;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.indigo.ars.DTO.FormDTO;
import com.indigo.ars.Entity.Form;
import com.indigo.ars.Entity.FormVersion;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;


@Service
@AllArgsConstructor
public class FormConverter {


    static final ObjectMapper objectMapper = new ObjectMapper();

    public static FormDTO FormConverterEntityToDTO(Form formEntity) throws JsonProcessingException {
        if (formEntity == null) {
            return null;
        }
        try {
            return objectMapper.readValue(formEntity.getData(), FormDTO.class);
        } catch (Exception e) {
            return null;
        }
    }

    public static FormDTO FormConverterVersionEntityToDTO(FormVersion formEntity) throws JsonProcessingException {
        if (formEntity == null) {
            return null;
        }
        try {
            return objectMapper.readValue(formEntity.getData(), FormDTO.class);
        } catch (Exception e) {
            return null;
        }

    }

    public static Form FormConverterDTOtoEntity(FormDTO formDTO) throws JsonProcessingException {
        if (formDTO == null) {
            return null;
        }

        return Form.builder()
                .datetime(parseDateTime(formDTO.getIncident().getDate(), formDTO.getIncident().getTime()))
                .type(formDTO.getIncident().getTypeOfIncident())
                .severity(formDTO.getProcedure().getHowLikely())
                .data(ConvertFormDTOToJson(formDTO))
                .build();
    }

    public static String ConvertFormDTOToJson(FormDTO formDTO) throws JsonProcessingException {
        return objectMapper.writeValueAsString(formDTO);
    }

    private static LocalDateTime parseDateTime(String date, String time) {
        DateTimeFormatter dateFormatter = DateTimeFormatter.ofPattern("yyyy-MM-dd");
        DateTimeFormatter timeFormatter = DateTimeFormatter.ofPattern("HH:mm");

        LocalDate localDate = LocalDate.parse(date, dateFormatter);
        LocalTime localTime = LocalTime.parse(time, timeFormatter);

        return LocalDateTime.of(localDate, localTime);
    }
}
