import { RetornoPadrao } from "../RetornoPadrao";

export interface UsuarioResponse extends RetornoPadrao
{
    data: DataUsuario
}

export interface DataUsuario
{
    nome: string,
    email: string,
    cpf: string,
    idUsuario: string,
    sessionKey: token
}

export interface token
{
    acess_token: string,
    expiration: string
}