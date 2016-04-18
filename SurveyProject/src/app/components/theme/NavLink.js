'use strict';

import React from 'react';
import {Link} from 'react-router';

export default class NavLink extends React.Component {

  render() {
    let path = this.context.location.pathname;
    let isActive = path.substring(0, this.props.to.length) == this.props.to;
    let className = isActive ? this.props.activeClassName : this.props.className;

    return <li className={className}>
      <Link {...this.props}/>
    </li>;
  }

}

NavLink.contextTypes = {
  history: React.PropTypes.object,
  location: React.PropTypes.object
};

NavLink.propTypes = {
  to: React.PropTypes.string.isRequired,
  query: React.PropTypes.object,
  hash: React.PropTypes.string,
  state: React.PropTypes.object,
  activeStyle: React.PropTypes.object,
  activeClassName: React.PropTypes.string,
  onClick: React.PropTypes.func
};

NavLink.defaultProps = {
  onlyActiveOnIndex: false,
  className: '',
  style: {}
};
