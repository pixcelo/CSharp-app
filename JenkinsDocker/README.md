
dockerイメージの取得
```bash
docker pull jenkins/jenkins:lts
```

コンテナ起動
```bash
docker run -p 8080:8080 -p 50000:50000 --restart=on-failure jenkins/jenkins:lts-jdk17
```