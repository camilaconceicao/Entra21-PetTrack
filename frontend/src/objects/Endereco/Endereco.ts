import { RetornoPadrao } from "../RetornoPadrao";

export interface Endereco extends RetornoPadrao
{
    data: DataEndereco
}

export interface DataEndereco
{
    cidade: string;
    bairro: string;
    rua: string;
}