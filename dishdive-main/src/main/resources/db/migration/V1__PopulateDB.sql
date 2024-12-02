CREATE TABLE chef (
    id              UUID NOT NULL,
    username        VARCHAR(250) NOT NULL,
    email           VARCHAR(254) NOT NULL,
    password        VARCHAR(250) NOT NULL,
    role            VARCHAR(250) NOT NULL,
    PRIMARY KEY (id),
    UNIQUE (username, email)
);

CREATE TABLE recipe (
    id              UUID NOT NULL,
    poster          UUID NOT NULL,
    title           VARCHAR(255) NOT NULL,
    description     VARCHAR(500),
    creation_time   TIMESTAMP NOT NULL,
    servings        INTEGER NOT NULL,
    prep_time       INTEGER NOT NULL,
    cook_time       INTEGER NOT NULL,
    recipe_tag      VARCHAR(250) NOT NULL,
    rating          NUMERIC(3,2),
    ingredients     TEXT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (poster) REFERENCES chef(id)
);

CREATE TABLE rating (
    id              UUID NOT NULL,
    recipe          UUID NOT NULL,
    rater           UUID NOT NULL,
    score           SMALLINT NOT NULL,
    comment         TEXT,
    PRIMARY KEY (id),
    FOREIGN KEY (recipe) REFERENCES recipe(id),
    FOREIGN KEY (rater) REFERENCES chef(id)
);

CREATE TABLE review (
    id              UUID NOT NULL,
    reviewer        UUID NOT NULL,
    rating          UUID NOT NULL,
    comment         VARCHAR(255) NOT NULL,
    creation_time   TIMESTAMP NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (reviewer) REFERENCES chef(id),
    FOREIGN KEY (rating) REFERENCES rating(id)
);
