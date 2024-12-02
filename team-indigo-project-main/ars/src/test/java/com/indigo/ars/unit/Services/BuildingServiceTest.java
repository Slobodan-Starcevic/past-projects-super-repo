package com.indigo.ars.unit.Services;

import com.indigo.ars.Converters.BuildingConverter;
import com.indigo.ars.DTO.BuildingDTO;
import com.indigo.ars.Entity.Building;
import com.indigo.ars.Repository.BuildingRepository;
import com.indigo.ars.Services.BuildingService;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;

import java.util.Arrays;
import java.util.List;
import java.util.Optional;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.ArgumentMatchers.*;
import static org.mockito.Mockito.*;

@ExtendWith(MockitoExtension.class)
class BuildingServiceTest {

    @Mock
    private BuildingRepository buildingRepository;

    @Mock
    private BuildingConverter buildingConverter;

    @InjectMocks
    private BuildingService buildingService;

    @Test
    void createBuilding() {
        BuildingDTO buildingDTO = BuildingDTO.builder()
                .address("Test Address")
                .city("Test City")
                .build();

        Building buildingEntity = buildingConverter.BuildingConverterDTOtoEntity(buildingDTO);
        when(buildingRepository.save(any(Building.class))).thenReturn(buildingEntity);

        BuildingDTO result = buildingService.createBuilding(buildingDTO);

        assertEquals(buildingDTO.getAddress(), result.getAddress());
        assertEquals(buildingDTO.getCity(), result.getCity());

        verify(buildingRepository, times(1)).save(any(Building.class));
    }

    @Test
    void getBuildingById() {
        int buildingId = 1; // Use UUID for buildingId
        Building buildingEntity = Building.builder()
                .id(buildingId)
                .address("Test Address")
                .city("Test City")
                .build();

        when(buildingRepository.findById(eq(buildingId))).thenReturn(Optional.of(buildingEntity));

        Optional<BuildingDTO> result = buildingService.getBuildingById(buildingId);

        assertEquals(buildingEntity.getAddress(), result.get().getAddress());
        assertEquals(buildingEntity.getCity(), result.get().getCity());

        verify(buildingRepository, times(1)).findById(eq(buildingId));
    }


    @Test
    void getBuildingByAddress() {
        String testAddress = "Test Address";
        Building buildingEntity = Building.builder()
                .address(testAddress)
                .city("Test City")
                .build();

        when(buildingRepository.getBuildingByAddress(eq(testAddress))).thenReturn(buildingEntity);

        Optional<BuildingDTO> result = buildingService.getBuildingByAddress(testAddress);

        assertEquals(testAddress, result.get().getAddress());
        assertEquals(buildingEntity.getCity(), result.get().getCity());

        verify(buildingRepository, times(1)).getBuildingByAddress(eq(testAddress));
    }

    @Test
    void getBuildingByCity() {
        String testCity = "Test City";
        Building buildingEntity = Building.builder()
                .address("Test Address")
                .city(testCity)
                .build();

        when(buildingRepository.getBuildingByCity(eq(testCity))).thenReturn(buildingEntity);

        Optional<BuildingDTO> result = buildingService.getBuildingByCity(testCity);

        assertEquals(buildingEntity.getAddress(), result.get().getAddress());
        assertEquals(testCity, result.get().getCity());

        verify(buildingRepository, times(1)).getBuildingByCity(eq(testCity));
    }

    @Test
    void getBuildingByAddressAndCity() {
        String testAddress = "Test Address";
        String testCity = "Test City";
        Building buildingEntity = Building.builder()
                .address(testAddress)
                .city(testCity)
                .build();

        when(buildingRepository.getBuildingByAddressAndCity(eq(testAddress), eq(testCity))).thenReturn(buildingEntity);

        Optional<BuildingDTO> result = buildingService.getBuildingByAddressAndCity(testAddress, testCity);

        assertEquals(testAddress, result.get().getAddress());
        assertEquals(testCity, result.get().getCity());

        verify(buildingRepository, times(1)).getBuildingByAddressAndCity(eq(testAddress), eq(testCity));
    }

    @Test
    void getAllBuildings() {
        List<Building> buildingEntities = Arrays.asList(
                Building.builder().address("Address1").city("City1").build(),
                Building.builder().address("Address2").city("City2").build()
        );

        when(buildingRepository.findAll()).thenReturn(buildingEntities);

        List<BuildingDTO> result = buildingService.getAllBuildings();

        assertEquals(buildingEntities.size(), result.size());
        assertEquals(buildingEntities.get(0).getAddress(), result.get(0).getAddress());
        assertEquals(buildingEntities.get(1).getCity(), result.get(1).getCity());

        verify(buildingRepository, times(1)).findAll();
    }
}
