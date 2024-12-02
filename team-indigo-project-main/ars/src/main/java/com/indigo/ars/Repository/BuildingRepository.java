package com.indigo.ars.Repository;

import com.indigo.ars.DTO.BuildingDTO;
import com.indigo.ars.Entity.Building;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.Optional;
import java.util.UUID;

@Repository
public interface BuildingRepository extends CrudRepository<Building, Integer> {
    Building getBuildingByAddress(String address);
    Building getBuildingByCity(String city);
    Building getBuildingByAddressAndCity(String address, String city);
}
