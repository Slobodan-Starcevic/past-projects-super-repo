package dishdive.business.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.server.ResponseStatusException;

public class AlreadyExistsException extends ResponseStatusException {
    public AlreadyExistsException(){super(HttpStatus.BAD_REQUEST, "ALREADY_EXISTS");}
}