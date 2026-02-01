-- name: ListUsers :many
SELECT * FROM users;

-- name: GetUser :one
SELECT * FROM users
WHERE id = ?
LIMIT 1;
