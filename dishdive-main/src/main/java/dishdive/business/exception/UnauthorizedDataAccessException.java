package dishdive.business.exception;

import org.springframework.http.HttpStatus;
import org.springframework.web.server.ResponseStatusException;

public class UnauthorizedDataAccessException extends ResponseStatusException {
    public UnauthorizedDataAccessException() {super(HttpStatus.FORBIDDEN, "UNAUTHORIZED_ACCESS_REQUEST");
    }
}
