package dishdive.business.annotation;

import jakarta.validation.Constraint;
import jakarta.validation.ConstraintValidator;
import jakarta.validation.ConstraintValidatorContext;
import jakarta.validation.Payload;

import java.lang.annotation.ElementType;
import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;
import java.lang.annotation.Target;
import java.util.UUID;

public class ValidUuidAnnotation {
    @Target({ ElementType.FIELD, ElementType.PARAMETER })
    @Retention(RetentionPolicy.RUNTIME)
    @Constraint(validatedBy = ValidUuidAnnotation.UUIDValidator.class)
    public @interface ValidUUID {
        String message() default "Invalid UUID";
        Class<?>[] groups() default {};
        Class<? extends Payload>[] payload() default {};
    }

    static class UUIDValidator implements ConstraintValidator<ValidUUID, UUID> {
        @Override
        public boolean isValid(UUID value, ConstraintValidatorContext context) {
            return value != null && isValidUUID(value.toString());
        }

        private boolean isValidUUID(String uuidStr) {
            try {
                UUID.fromString(uuidStr);
                return true;
            } catch (IllegalArgumentException e) {
                return false;
            }
        }
    }
}
