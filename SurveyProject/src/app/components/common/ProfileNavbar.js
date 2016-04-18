import React from 'react';
import ReactDOM from 'react-dom';
import classNames from 'classnames';
import {Link} from 'react-router';

export default class ProfileNavBar extends React.Component {

  static defaultProps = {
    userName: 'Guest',
    onLogout: () => {}
  };

  static propTypes = {
    userName: React.PropTypes.string,
    onLogout: React.PropTypes.func
  };

  state = {
    isProfileOpened: false,
    mounted: false
  };

  constructor(props) {
    super(props);
    document.addEventListener('click', this.handleDocumentClick, false);
  }

  componentWillUnmount() {
    document.removeEventListener('click', this.handleDocumentClick, false);
  }

  handleDocumentClick = (e) => {
    if (!ReactDOM.findDOMNode(this).contains(e.target)) {
      this.setState({isProfileOpened: false});
    }
  };

  toggleProfile = (e) => {
    e.preventDefault();
    this.setState({
      isProfileOpened: !this.state.isProfileOpened
    })
  };

  render() {
    let dropDownClass = classNames('dropdown uui-profile-menu', {open: this.state.isProfileOpened});

    return <ul className="uui-navigation right nav navbar-nav">
      <li className={dropDownClass}>
        <a href="#" className="dropdown-toggle" data-toggle="dropdown" onClick={this.toggleProfile}>
          <span className="profile-name">{this.props.userName}</span>
          <div className="profile-photo">
            <img src="lib/uui/images/icons/no_photo.png" alt=""/>
          </div>
          <span className="caret"></span>
        </a>
        <ul className="dropdown-menu" role="menu">
          <li className="dropdown-menu-links"><Link to={"/options/users/" + this.props.userId}>Profile</Link></li>
          <li className="dropdown-menu-links"><Link to="/login" onClick={this.props.onLogout}>Logout</Link></li>
        </ul>
      </li>
    </ul>
  }

}
