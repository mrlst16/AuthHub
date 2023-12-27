import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { OrganizationSignin } from './pages/organization/organization_signin';
import { HomeSplash } from './pages/homesplash';
import { MemberSignup } from './pages/member/member_signup';
import { OrganizationHome } from './pages/organization/organization_home';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <BrowserRouter>
  <Routes>
  <Route path='/organization' element={<OrganizationHome />}>
      <Route>
        <Route path='signin' element={<OrganizationSignin />} />
      </Route>
    </Route>
    <Route path='/member' element={<App />}>
      <Route>
        <Route path='signup' element={<MemberSignup />} />
      </Route>
    </Route>
    <Route index element={<HomeSplash />}></Route>
    <Route path='*' element={<HomeSplash />}></Route>
  </Routes>
   
  </BrowserRouter>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
