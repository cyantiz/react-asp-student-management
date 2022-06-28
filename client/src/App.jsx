import React from "react";
import { useState } from "react";
import { BrowserRouter as Router, Route, Switch, Redirect } from "react-router-dom";
import LoggedView from "./layouts/LoggedView";
import Auth from "./layouts/Auth"
import { useEffect } from "react";
import axios from 'axios'
function App() {
    // axios.defaults.baseURL = "http://172.21.10.108:5193/"
    axios.defaults.baseURL = "http://192.168.1.4:5193/"
    axios.defaults.timeout = "10000"
    axios.defaults.timeoutErrorMessage = "Request timeout"
    axios.defaults.headers.common['Authorization'] = `Bearer ${localStorage.getItem("jwt")}`;

    const parseJwt = (token) => {
        if (token === null)
            return false
        var base64Url = token.split('.')[1];
        var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function(c) {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }).join(''));
    
        return JSON.parse(jsonPayload);
    };

    const [jwt, setJwt] = useState(localStorage.getItem("jwt"));
    const [user, setUser] = useState(parseJwt(localStorage.getItem("jwt")));
    // const [user, setUser] = useState({
    //     role: 'Admin',
    //     name: 'admin01'
    // });

    useEffect(() => {

    }, [])

    const handleLogout = () => {
        localStorage.removeItem("jwt");
        window.location.reload();
    }

    return (
        <div className="App">
            <Router>
                <Switch>
                    <Route path="/auth">
                        <LoggedView user={user} handleLogout={handleLogout} />
                        {!user && <Redirect to="/unauth" />}
                    </Route>
                    <Route path="/unauth">
                        <Auth user={user} />
                        {user && <Redirect to="/auth" />}
                    </Route>
                    <Route path="*">
                        {user ? <Redirect to="/auth" /> : <Redirect to="/unauth" />}
                    </Route>
                </Switch>
            </Router>
        </div>
    );
}

export default App;
