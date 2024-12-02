package dishdive.business.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.server.ResponseStatusException;

public class UnknownErrorException extends ResponseStatusException {
    public UnknownErrorException(){super(HttpStatus.BAD_REQUEST, "IDK_WHAT_HAPPENED");}
}
