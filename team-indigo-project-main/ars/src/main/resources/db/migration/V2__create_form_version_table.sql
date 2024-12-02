CREATE TABLE IF NOT EXISTS version (
                                       id           SERIAL PRIMARY KEY,
                                       version      INTEGER NOT NULL,
                                       changer_id   INTEGER,
                                       form_id      INTEGER,
                                       datetime     TIMESTAMP WITHOUT TIME ZONE NOT NULL,
                                       data         TEXT,
                                       message      VARCHAR(100),

    CONSTRAINT fk_version_changer FOREIGN KEY (changer_id) REFERENCES employee(id),
    CONSTRAINT fk_version_form FOREIGN KEY (form_id) REFERENCES form(id)
    );
