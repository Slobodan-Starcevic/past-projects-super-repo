package dishdive.configuration.security.token;

public interface AccessTokenEncoder {
    String encode(AccessToken accessToken);
}