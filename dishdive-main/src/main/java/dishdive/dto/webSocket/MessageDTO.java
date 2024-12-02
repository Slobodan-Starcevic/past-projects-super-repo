package dishdive.dto.webSocket;

import lombok.Data;

@Data
public class MessageDTO {
    private String id;
    private String from;
    private String to;
    private String text;
}
