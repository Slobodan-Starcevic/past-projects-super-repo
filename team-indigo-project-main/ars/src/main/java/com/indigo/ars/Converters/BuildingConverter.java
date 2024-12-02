package com.indigo.ars.Converters;

import com.indigo.ars.DTO.BuildingDTO;
import com.indigo.ars.Entity.Building;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

@Service
@AllArgsConstructor
public class BuildingConverter {

    public static BuildingDTO BuildingConverterEntityDTO(Building buildingEntity) {
        if (buildingEntity == null) {
            return null;
        }

        return BuildingDTO.builder()
                .address(buildingEntity.getAddress())
                .city(buildingEntity.getCity())
                .build();
    }

    public static Building BuildingConverterDTOtoEntity(BuildingDTO buildingDTO) {
        if (buildingDTO == null) {
            return null;
        }

        Building buildingEntity = new Building();
        buildingEntity.setAddress(buildingDTO.getAddress());
        buildingEntity.setCity(buildingDTO.getCity());

        return buildingEntity;
    }
}
