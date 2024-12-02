package dishdive.configuration.security.token.impl;

import dishdive.configuration.security.token.AccessToken;
import lombok.EqualsAndHashCode;
import lombok.Getter;

import java.util.UUID;

@EqualsAndHashCode
@Getter
public class AccessTokenImpl implements AccessToken {
    private final String subject;
    private final UUID userId;
    private final String role;

    public AccessTokenImpl(String subject, UUID userId, String role){
        this.subject = subject;
        this.userId = userId;
        this.role = role;
    }

    @Override
    public boolean hasRole(String roleName){
        return this.role.equals(roleName);
    }
}
