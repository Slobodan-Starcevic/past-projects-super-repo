package dishdive.configuration.security.token;

import java.util.UUID;

public interface AccessToken {
    String getSubject();
    UUID getUserId();
    String getRole();
    boolean hasRole(String roleName);
}
