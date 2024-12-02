package dishdive.business.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.server.ResponseStatusException;

public class InvalidRequestException extends ResponseStatusException {
    public InvalidRequestException(){super(HttpStatus.BAD_REQUEST, "INVALID_REQUEST");}
}
