import { RetornoPadrao } from "../RetornoPadrao"

export interface PetResponse extends RetornoPadrao
{
    data: Array<DataPet>
}

export interface DataPet{
    longitude: string,
    latitude: string,
    fotoBase64: string,
    usuarioCadastroId: number,
    dataCadastro: string,
    tamanho: string,
    nome: string,
    descricao: string
}

