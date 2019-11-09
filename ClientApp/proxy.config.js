const proxy = [
  {
    context: '/api',
    target: 'http://localhost:57630',
    pathRewrite: {'^/api' : '/amigo'}
  }
];
module.exports = proxy;