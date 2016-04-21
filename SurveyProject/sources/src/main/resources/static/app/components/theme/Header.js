import React from 'react'
import {Link} from 'react-router'
import {Nav, Navbar, NavItem, NavDropdown, MenuItem} from 'react-bootstrap'
import NavLink from './NavLink'
import ProfileNavBar from '../common/ProfileNavbar'

export default class Header extends React.Component {

  render() {
    return <header className="header">
      <div className="uui-header dark-green">
        <nav role="navigation">
          <Link to="/" className="brand-logo">Survey</Link>
          <ul className="uui-navigation nav navbar-nav">
            <NavLink activeClassName="active" to="/"><span>Dashboard</span></NavLink>
            <NavLink activeClassName="active" to="/builder"><span>Form builder</span></NavLink>
          </ul>
          {'true' ? // @todo Authorization check profile
            <ProfileNavBar userName="Guest" userId={0} onLogout={() => { alert('logout'); }}/>
            : ''}
        </nav>
      </div>
    </header>;
  }

}
