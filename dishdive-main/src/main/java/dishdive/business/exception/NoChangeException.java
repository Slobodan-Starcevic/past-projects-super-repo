package dishdive.business.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.server.ResponseStatusException;

public class NoChangeException extends ResponseStatusException {
    public NoChangeException() {
        super(HttpStatus.BAD_REQUEST, "INVALID_REQUEST");
    }
}
