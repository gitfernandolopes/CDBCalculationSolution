const PROXY_CONFIG = [
  {
    context: [
      "/api",
    ],
    target: "https://localhost:44300/",
    secure: false,
    changeOrigin: true,
    pathRewrite: {
      "^/": ""
    }
  }
]

module.exports = PROXY_CONFIG;
