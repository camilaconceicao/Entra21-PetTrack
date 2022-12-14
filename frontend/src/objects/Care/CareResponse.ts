import { RetornoPadrao } from "../RetornoPadrao"

export interface CareResponse extends RetornoPadrao
{
    data: {
        itens: Array<DataCare>
    }
}

export interface DataCare{
    nome: string,
    descricao: string,
    fotoBase64:string
}

