import { RedeSocial } from './RedeSocial';
import { Lote } from './Lote';
import { Palestrante } from './Palestrante';

export interface Evento {
     id: number;
     local: string;
     dataEvento: Date;
     tema: string;
     qtdPessoas: number;
     imgUrl: string;
     telefone: string;
     email: string;
     lotes: Lote[];
     redesSociais: RedeSocial[];
     palestranteEventos: Palestrante[];
}
