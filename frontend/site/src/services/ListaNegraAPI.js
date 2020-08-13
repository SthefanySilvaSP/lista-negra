import axios from 'axios';

const api = axios.create({
    baseURL: 'https://lista-negra.vercel.app/'
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
}