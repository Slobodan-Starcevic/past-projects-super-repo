package com.indigo.ars.unit.Converter;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.indigo.ars.Converters.BuildingConverter;
import com.indigo.ars.DTO.BuildingDTO;
import com.indigo.ars.Entity.Building;
import org.junit.jupiter.api.Test;
import org.mockito.Mock;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class BuildingConverterTest {

    @Mock
    private ObjectMapper objectMapper;

    @Mock
    private BuildingConverter buildingConverter;

    @Test
    void buildingConverterEntityToDTO() {
        Building buildingEntity = Building.builder()
                .address("Test Address")
                .city("Test City")
                .build();

        BuildingDTO result = buildingConverter.BuildingConverterEntityDTO(buildingEntity);

        assertEquals(buildingEntity.getAddress(), result.getAddress());
        assertEquals(buildingEntity.getCity(), result.getCity());
    }

    @Test
    void buildingConverterDTOToEntity() {
        BuildingDTO buildingDTO = BuildingDTO.builder()
                .address("Test Address")
                .city("Test City")
                .build();

        Building result = buildingConverter.BuildingConverterDTOtoEntity(buildingDTO);

        assertEquals(buildingDTO.getAddress(), result.getAddress());
        assertEquals(buildingDTO.getCity(), result.getCity());
    }
}
