-- +goose Up
-- +goose StatementBegin
CREATE TABLE users(
    id TEXT primary key,
    email TEXT not null unique,
    phone TEXT not null unique,

    first_name TEXT not null,
    last_name TEXT not null,
    date_of_birth INTEGER not null,

    licence_url TEXT not null,
    passport_url TEXT not null,
    international_driving_permit_url TEXT not null,

    created_at INTEGER not null
);

CREATE TABLE roles (
    id TEXT primary key,
    name TEXT not null unique
);

CREATE TABLE user_roles(
    user_id TEXT not null,
    role_id TEXT not null,

    constraint ur_users_fk FOREIGN KEY(user_id) REFERENCES users(id),
    constraint ur_roles_fk FOREIGN KEY(role_id) REFERENCES roles(id),

    primary key (user_id, role_id)
);
-- +goose StatementEnd

-- +goose Down
-- +goose StatementBegin
DROP TABLE users;
DROP TABLE roles;
DROP TABLE user_roles;
-- +goose StatementEnd
