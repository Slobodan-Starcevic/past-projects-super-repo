package com.indigo.ars.Services;

import com.indigo.ars.Converters.BuildingConverter;
import com.indigo.ars.DTO.BuildingDTO;
import com.indigo.ars.Entity.Building;
import com.indigo.ars.Repository.BuildingRepository;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;
import java.util.stream.StreamSupport;


@Service
public class BuildingService {

    private final BuildingRepository buildingRepository;

    private final BuildingConverter buildingConverter;

    public BuildingService(BuildingRepository buildingRepository, BuildingConverter buildingConverter) {
        this.buildingRepository = buildingRepository;
        this.buildingConverter = buildingConverter;
    }

    public BuildingDTO createBuilding(BuildingDTO buildingDTO) {
        Building building = buildingConverter.BuildingConverterDTOtoEntity(buildingDTO);
        Building savedBuilding = buildingRepository.save(building);
        return buildingConverter.BuildingConverterEntityDTO(savedBuilding);
    }

/*    public Optional<BuildingDTO> getBuildingById(Long id) {
        Optional<Building> buildingOptional = buildingRepository.findById(id);
        return buildingOptional.map(BuildingConverter::BuildingConverterEntitytoDTO);
    }*/

    public Optional<BuildingDTO> getBuildingById(int id) {
        Optional<Building> buildingOptional = buildingRepository.findById(id);
        return buildingOptional.map(BuildingConverter::BuildingConverterEntityDTO);
    }

    public Optional<BuildingDTO> getBuildingByAddress(String address) {
        Building building = buildingRepository.getBuildingByAddress(address);
        return Optional.ofNullable(buildingConverter.BuildingConverterEntityDTO(building));
    }

    public Optional<BuildingDTO> getBuildingByCity(String city) {
        Building building = buildingRepository.getBuildingByCity(city);
        return Optional.ofNullable(buildingConverter.BuildingConverterEntityDTO(building));
    }

    public Optional<BuildingDTO> getBuildingByAddressAndCity(String address, String city) {
        Building building = buildingRepository.getBuildingByAddressAndCity(address, city);
        return Optional.ofNullable(buildingConverter.BuildingConverterEntityDTO(building));
    }

    public List<BuildingDTO> getAllBuildings() {
        Iterable<Building> buildings = buildingRepository.findAll();
        return StreamSupport.stream(buildings.spliterator(), false)
                .map(BuildingConverter::BuildingConverterEntityDTO)
                .collect(Collectors.toList());
    }
}
