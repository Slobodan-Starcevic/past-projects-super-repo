package com.indigo.ars.Controller;

import com.indigo.ars.DTO.BuildingDTO;
import com.indigo.ars.Services.BuildingService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Optional;

@RestController
@RequestMapping("/buildings")
public class BuildingController {
    private final BuildingService buildingService;

    public BuildingController(BuildingService buildingService) {
        this.buildingService = buildingService;
    }

    @GetMapping
    public ResponseEntity<Iterable<BuildingDTO>> getAllBuildings() {
        return ResponseEntity.ok(buildingService.getAllBuildings());
    }

    @GetMapping("/{address}")
    public ResponseEntity<Optional<BuildingDTO>> getBuildingByAddress(@RequestBody String address) {
        return ResponseEntity.ok(buildingService.getBuildingByAddress(address));
    }

    @GetMapping("/{city}")
    public ResponseEntity<Optional<BuildingDTO>> getBuildingByCity(@RequestBody String city) {
        return ResponseEntity.ok(buildingService.getBuildingByCity(city));
    }

    @GetMapping("/{address}/{city}")
    public ResponseEntity<Optional<BuildingDTO>> getBuildingByAddressAndCity(@RequestBody String address, @RequestBody String city) {
        return ResponseEntity.ok(buildingService.getBuildingByAddressAndCity(address, city));
    }
    //id tbd

    @PostMapping
    public ResponseEntity<BuildingDTO> addBuilding(@RequestBody BuildingDTO building) {
        return ResponseEntity.ok(buildingService.createBuilding(building));
    }
}
