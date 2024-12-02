package dishdive.controller;

import dishdive.business.ChefServiceInterface;
import dishdive.dto.chef.request.*;
import dishdive.dto.chef.response.ChefListResponse;
import dishdive.dto.chef.response.LoginResponse;
import dishdive.dto.chef.response.SingleChefResponse;
import dishdive.dto.recipe.response.RecipeListResponse;
import dishdive.dto.shared.response.BooleanResponse;
import dishdive.dto.shared.response.UUIDResponse;
import jakarta.annotation.security.RolesAllowed;
import jakarta.validation.Valid;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.UUID;

@RestController
@RequestMapping("/chef")
@AllArgsConstructor
public class ChefController {
    private final ChefServiceInterface chefServiceInterface;

    @RolesAllowed({"ADMIN"})
    @GetMapping
    public ResponseEntity<ChefListResponse> getAllChefs() {
        return ResponseEntity.ok(chefServiceInterface.getAllChefs());
    }

    @GetMapping("/getOne/{chefId}")
    public ResponseEntity<SingleChefResponse> getChefById(@PathVariable UUID chefId) {
        ChefIdRequest requestDTO = new ChefIdRequest(chefId);
        SingleChefResponse response = chefServiceInterface.getChefById(requestDTO);
        return ResponseEntity.ok(response);
    }

    @GetMapping("/{chefUsername}")
    public ResponseEntity<SingleChefResponse> getChefByUsername(@PathVariable String chefUsername){
        ChefUsernameRequest requestDTO = new ChefUsernameRequest(chefUsername);
        SingleChefResponse response = chefServiceInterface.getChefByUsername(requestDTO);
        return ResponseEntity.ok(response);
    }

    @GetMapping("/{chefId}/recipes")
    public ResponseEntity<RecipeListResponse> getChefRecipes(@PathVariable UUID chefId) {
        ChefIdRequest requestDTO = new ChefIdRequest(chefId);
        RecipeListResponse response = chefServiceInterface.getChefRecipes(requestDTO);
        return ResponseEntity.ok(response);
    }

    @PostMapping("/create")
    public ResponseEntity<UUIDResponse> createChef(@RequestBody @Valid ChefDataRequest requestDTO) {
        UUIDResponse response = chefServiceInterface.createChef(requestDTO);
        return ResponseEntity.status(HttpStatus.CREATED).body(response);
    }

    @PostMapping("/login")
    public ResponseEntity<LoginResponse> loginChef(@RequestBody @Valid LoginRequest loginRequest) {
        LoginResponse loginResponse = chefServiceInterface.loginChef(loginRequest);
        return ResponseEntity.status(HttpStatus.CREATED).body(loginResponse);
    }

    @RolesAllowed({"CHEF", "SUPER_CHEF", "ADMIN"})
    @PutMapping("/{chefId}")
    public ResponseEntity<UUIDResponse> updateChefUsernameAndEmail(@PathVariable UUID chefId, @RequestBody @Valid ChefUsernameAndEmailChangeRequest requestDTO) {
        requestDTO.setId(chefId);
        UUIDResponse response = chefServiceInterface.updateChef(requestDTO);
        return ResponseEntity.ok(response);
    }

    @RolesAllowed({"CHEF", "SUPER_CHEF", "ADMIN"})
    @PutMapping("/update-password/{chefId}")
    public ResponseEntity<BooleanResponse> updateChefPassword(@PathVariable UUID chefId, @RequestBody @Valid ChangePasswordChangeRequest requestDTO) {
        requestDTO.setId(chefId);
        BooleanResponse response = chefServiceInterface.updateChefPassword(requestDTO);
        return ResponseEntity.ok(response);
    }

    @RolesAllowed({"CHEF", "SUPER_CHEF", "ADMIN"})
    @DeleteMapping("/{chefId}")
    public ResponseEntity<Void> deleteChef(@PathVariable UUID chefId) {
        ChefIdRequest requestDTO = new ChefIdRequest(chefId);
        chefServiceInterface.deleteChef(requestDTO);
        return ResponseEntity.ok().build();
    }
}

