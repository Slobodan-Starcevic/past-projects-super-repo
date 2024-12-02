package dishdive.business.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.server.ResponseStatusException;

public class NoUserFoundException extends ResponseStatusException {
    public NoUserFoundException(){super(HttpStatus.BAD_REQUEST, "NO_USER_FOUND");}
}
