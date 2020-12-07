import { Test, TestingModule } from '@nestjs/testing';
import { MowLawnController } from './mow-lawn.controller';

describe('MowLawnController', () => {
  let controller: MowLawnController;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      controllers: [MowLawnController],
    }).compile();

    controller = module.get<MowLawnController>(MowLawnController);
  });

  it('should be defined', () => {
    expect(controller).toBeDefined();
  });
});
