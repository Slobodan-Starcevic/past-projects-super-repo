package dishdive.business.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.server.ResponseStatusException;

public class NotFoundException extends ResponseStatusException {
    public NotFoundException(){super(HttpStatus.BAD_REQUEST, "NOT_FOUND");}
}

