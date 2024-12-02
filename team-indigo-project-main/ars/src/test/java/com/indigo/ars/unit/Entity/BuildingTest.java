package com.indigo.ars.unit.Entity;

import com.indigo.ars.Entity.Building;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

public class BuildingTest {

    private Building building;

    @BeforeEach
    public void setUp() {
        building = Building.builder()
                .id(1)
                .address("123 Main St")
                .city("Cityville")
                .build();
    }

    @Test
    public void testGetters() {
        assertEquals(1, building.getId());
        assertEquals("123 Main St", building.getAddress());
        assertEquals("Cityville", building.getCity());
    }

    @Test
    public void testNoArgsConstructor() {
        Building defaultBuilding = new Building();
        assertNull(defaultBuilding.getId());
        assertNull(defaultBuilding.getAddress());
        assertNull(defaultBuilding.getCity());
    }

    @Test
    public void testAllArgsConstructor() {
        Building allArgsBuilding = new Building(2, "456 Oak St", "Townsville");
        assertEquals(2, allArgsBuilding.getId());
        assertEquals("456 Oak St", allArgsBuilding.getAddress());
        assertEquals("Townsville", allArgsBuilding.getCity());
    }

    @Test
    public void testBuilder() {
        Building builtBuilding = Building.builder()
                .id(3)
                .address("789 Pine St")
                .city("Villageville")
                .build();

        assertEquals(3, builtBuilding.getId());
        assertEquals("789 Pine St", builtBuilding.getAddress());
        assertEquals("Villageville", builtBuilding.getCity());
    }


    @Test
    public void testEqualsAndHashCode() {
        Building sameBuilding = Building.builder()
                .id(1)
                .address("123 Main St")
                .city("Cityville")
                .build();

        Building differentBuilding = Building.builder()
                .id(2)
                .address("456 Oak St")
                .city("Townsville")
                .build();

        assertEquals(building, sameBuilding);
        assertNotEquals(building, differentBuilding);

        assertEquals(building.hashCode(), sameBuilding.hashCode());
        assertNotEquals(building.hashCode(), differentBuilding.hashCode());
    }

    @Test
    public void testToString() {
        String expectedToString = "Building(id=1, address=123 Main St, city=Cityville)";
        assertEquals(expectedToString, building.toString());
    }

    @Test
    public void testEqualsAndHashCodeWithNullFields() {
        // Ensure that equals and hashCode handle null fields correctly
        Building buildingWithNulls = Building.builder().build();
        assertNotEquals(building, buildingWithNulls);
        assertNotEquals(building.hashCode(), buildingWithNulls.hashCode());
    }

}
