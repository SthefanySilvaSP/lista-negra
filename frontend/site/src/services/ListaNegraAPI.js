import axios from 'axios';

const api = axios.create({
    baseURL: 'https://nsf-lista-negra.herokuapp.com/listanegra'
}); 

export default class ListaNegraAPI {
    
    async cadastrar(ln) {
        const resp = await api.post('/ListaNegra', ln);   
        return resp;
    }

    async consultar() {
        const resp = await api.get('/ListaNegra');
        return resp.data;
    }

    async excluir(id) {
        const resp = await api.delete('/ListaNegra/' + id);
    }
}
