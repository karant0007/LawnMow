import { Module } from '@nestjs/common';
import { from } from 'rxjs';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { ApiresponseModule } from './apiresponse/apiresponse.module';
import { MowLawnServiceService } from './mow-lawn-service/mow-lawn-service.service';
import { MowLawnController } from './mow-lawn/mow-lawn.controller';

@Module({
  imports: [ApiresponseModule],
  controllers: [AppController, MowLawnController],
  providers: [AppService, MowLawnServiceService],
})
export class AppModule { }
