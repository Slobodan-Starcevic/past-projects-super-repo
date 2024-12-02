-- DO NOT CHANGE THE ORDER OF THE TABLES (tables need to be created before they can be referenced)
CREATE TABLE building (
    id              SERIAL         PRIMARY KEY,
    address         VARCHAR(255)    NOT NULL,
    city            VARCHAR(255)    NOT NULL
);

CREATE TABLE employee (
    id              SERIAL         PRIMARY KEY,
    first_name      VARCHAR(255),
    middle_name     VARCHAR(255),
    last_name       VARCHAR(255),
    phone_number    VARCHAR(255),
    email           VARCHAR(255),
    role            VARCHAR(255)
);

CREATE TABLE form (
    id              SERIAL          PRIMARY KEY,
    type            character varying[]    NOT NULL,
    datetime        TIMESTAMP       WITHOUT TIME ZONE NOT NULL,
    status          VARCHAR(255)    NOT NULL,
    severity        VARCHAR(255)    NOT NULL,
    data            TEXT            NOT NULL,
    building_id     INTEGER         NOT NULL,
    reporter_id     INTEGER         NOT NULL,
    FOREIGN KEY (building_id) REFERENCES building(id),
    FOREIGN KEY (reporter_id) REFERENCES employee(id)
);


-- Insert dummy data for the building table
INSERT INTO building (address, city) VALUES
                                         ('123 Main St', 'Cityville'),
                                         ('456 Oak Ave', 'Townburg'),
                                         ('789 Pine Rd', 'Villagetown');

-- Insert dummy data for the employee table
INSERT INTO employee (first_name, last_name, role) VALUES
                                                       ('John', 'Doe', 'Manager'),
                                                       ('Jane', 'Smith', 'Technician'),
                                                       ('Bob', 'Johnson', 'Supervisor');

-- Insert dummy data for the form table with an array of types
INSERT INTO form (type, datetime, status, severity, data, building_id, reporter_id) VALUES
    ('{"Maintenance", "Repair"}', '2024-01-10 09:15:00', 'Open', 'Medium', 'Maintenance and repair details', 1, 2);
