-- name: ListUsers :many
SELECT * FROM users
LIMIT sqlc.arg(limit)
OFFSET sqlc.arg(offset);

-- name: GetUser :one
SELECT * FROM users
WHERE id = sqlc.arg(userID)
LIMIT 1;
