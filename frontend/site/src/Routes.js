import React from 'react';
import { Switch, BrowserRouter, Route } from 'react-router-dom';

import App from './pages/App';
import Cadastrar from './pages/Cadastrar';
import Consultar from './pages/Consultar';

export default function Routes() {
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" exact={true} component={App} />
                <Route path="/cadastrar" component={Cadastrar}/>
                <Route path="/consultar" component={Consultar}/>
            </Switch>
        </BrowserRouter>
    );
}