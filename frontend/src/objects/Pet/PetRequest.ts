export interface PetRequest {
    IdPet: number | undefined | null,
    Nome: string | undefined | null,
    FotoBase64: string | undefined | null,
    Raca: string | undefined | null,
    Tamanho: number | undefined | null,
    Cep: string | undefined | null,
    Cidade: string | undefined | null,
    Bairro: string | undefined | null,
    Rua: string | undefined | null,
    Descricao: string | undefined | null,
    TipoCadastro: number | undefined | null,
    UsuarioCadastroId: string | undefined | null
}

