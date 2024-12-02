package com.indigo.ars.Services;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.http.HttpHeaders;
import org.springframework.http.MediaType;
import org.springframework.http.RequestEntity;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

import java.net.URI;
import java.net.URISyntaxException;
@Service
public class MailgunEmailService {

    @Value("${mailgun.api-key}")
    private String apiKey;

    @Value("${mailgun.domain}")
    private String domain;

    @Value("${mailgun.sender-email}")
    private String senderEmail;  // Add this line to retrieve sender email from properties

    public ResponseEntity<String> sendSimpleMessage(String to, String subject, String text) throws URISyntaxException {
        RestTemplate restTemplate = new RestTemplate();

        HttpHeaders headers = new HttpHeaders();
        headers.setContentType(MediaType.APPLICATION_FORM_URLENCODED);
        headers.setBasicAuth("api", apiKey);

        String url = "https://api.mailgun.net/v3/" + domain + "/messages";
        String body = "from=" + senderEmail + "&to=" + to + "&subject=" + subject + "&text=" + text;

        RequestEntity<String> requestEntity = RequestEntity.post(new URI(url)).headers(headers).body(body);
        return restTemplate.exchange(requestEntity, String.class);
    }
}
