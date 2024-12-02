package dishdive.configuration;

import dishdive.business.ChefServiceInterface;
import dishdive.dto.chef.request.ChefDataRequest;
import dishdive.persistence.repository.ChefRepository;
import jakarta.transaction.Transactional;
import lombok.AllArgsConstructor;
import org.springframework.boot.context.event.ApplicationReadyEvent;
import org.springframework.context.event.EventListener;
import org.springframework.stereotype.Component;

@Component
@AllArgsConstructor
public class Dummy {
    private final ChefServiceInterface chefServiceInterface;
    private final ChefRepository chefRepository;

    @EventListener(ApplicationReadyEvent.class)
    @Transactional
    public void populateDatabaseInitialDummyData() {
        if(chefRepository.count() == 0){
            createDummyChefs();
        }
    }

    private void createDummyChefs(){
        ChefDataRequest chef = ChefDataRequest.builder()
                .username("chef")
                .email("chef@gmail.com")
                .password("Chef123")
                .build();
        chefServiceInterface.createChef(chef);

        ChefDataRequest admin = ChefDataRequest.builder()
                .username("admin")
                .email("admin@gmail.com")
                .password("Admin123")
                .build();
        chefServiceInterface.createAdmin(admin);
    }

}
