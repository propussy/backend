-- +goose Up
-- +goose StatementBegin
CREATE TABLE companies (
    id TEXT PRIMARY KEY,
    user_id TEXT NOT NULL,
    -- TODO: Think about bank details
    status TEXT NOT NULL DEFAULT 'Pending'
);

CREATE TABLE company_docs (
    id TEXT PRIMARY KEY,
    url TEXT NOT NULL,
    company_id TEXT NOT NULL,
    CONSTRAINT docs_company_fk FOREIGN KEY (company_id)
        REFERENCES companies(id)
);

CREATE TABLE insurance(
    id TEXT PRIMARY KEY,
    name TEXT NOT NULL,
    title TEXT NOT NULL,
    description TEXT NOT NULL
);

CREATE TABLE cars (
    id TEXT PRIMARY KEY,
    daily_price REAL NOT NULL,
    weekly_price REAL NOT NULL,
    monthly_price REAL NOT NULL,
    deposit REAL NOT NULL,
    mileage_limit REAL NOT NULL,
    color TEXT NOT NULL,
    seats INTEGER NOT NULL,
    doors INTEGER NOT NULL,
    year TEXT NOT NULL,
    body_type TEXT NOT NULL,
    power_hp INTEGER NOT NULL,
    fuel_type TEXT NOT NULL,
    transmission TEXT NOT NULL,
    drive_type TEXT NOT NULL,
    insurance_id TEXT NOT NULL,
    company_id TEXT NOT NULL,
    FOREIGN KEY(insurance_id) REFERENCES insurance(id),
    CONSTRAINT cars_company_fk FOREIGN KEY (company_id)
        REFERENCES companies(id)
);

CREATE TABLE car_availability(
    id TEXT primary key,

    _from TEXT not null,
    _to TEXT not null,

    car_id TEXT not null,
    CONSTRAINT car_availability_cars_fk FOREIGN KEY (car_id)
         REFERENCES cars(id) 
);

CREATE TABLE rents(
    id TEXT primary key,

    _from TEXT not null,
    _to TEXT not null,

    car_id TEXT not null,
    CONSTRAINT car_availability_cars_fk FOREIGN KEY (car_id)
         REFERENCES cars(id) 

    client_id TEXT not null
);

CREATE TABLE photos(
    id TEXT PRIMARY KEY,
    car_id TEXT NOT NULL,
    url TEXT NOT NULL,
    FOREIGN KEY(car_id) REFERENCES cars(id)
);

-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
DROP TABLE companies;
DROP TABLE company_docs;
DROP TABLE cars;
DROP TABLE insurance;
-- +goose StatementEnd
