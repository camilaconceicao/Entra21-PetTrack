import { RetornoPadrao } from "../RetornoPadrao"

export interface OngResponse extends RetornoPadrao
{
    data: {
        itens: Array<DataOng>
    }
}

export interface DataOng{
    nome: string,
    razaoSocial: string,
    email: string,
    pix: string,
    descricao: string,
    fotoBase64:string
}

