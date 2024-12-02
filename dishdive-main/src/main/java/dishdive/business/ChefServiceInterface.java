package dishdive.business;

import dishdive.dto.chef.request.*;
import dishdive.dto.chef.response.ChefListResponse;
import dishdive.dto.chef.response.LoginResponse;
import dishdive.dto.chef.response.SingleChefResponse;
import dishdive.dto.recipe.response.RecipeListResponse;
import dishdive.dto.shared.response.BooleanResponse;
import dishdive.dto.shared.response.UUIDResponse;

public interface ChefServiceInterface {
    UUIDResponse createChef(ChefDataRequest requestDTO);
    UUIDResponse createAdmin(ChefDataRequest requestDTO);

    LoginResponse loginChef(LoginRequest requestDTO);

    ChefListResponse getAllChefs();

    SingleChefResponse getChefById(ChefIdRequest requestDTO);

    SingleChefResponse getChefByUsername(ChefUsernameRequest requestDTO);

    RecipeListResponse getChefRecipes(ChefIdRequest requestDTO);

    UUIDResponse updateChef(ChefUsernameAndEmailChangeRequest requestDTO);

    BooleanResponse updateChefPassword(ChangePasswordChangeRequest requestDTO);

    BooleanResponse deleteChef(ChefIdRequest requestDTO);
}

