import jwt_decode from 'jwt-decode'

const decodedToken = (token) => {
    jwt_decode(token);
}

export default decodedToken;